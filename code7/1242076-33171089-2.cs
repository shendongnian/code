    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using System.Runtime.InteropServices;
    using System.Drawing.Text;
    using System.Drawing;
    
    public static class MemoryFonts {
    		
    	[DllImport( "gdi32.dll" )]
    	private static extern IntPtr AddFontMemResourceEx( IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts );
    	private static PrivateFontCollection pfc { get; set; }
    
    	static MemoryFonts() {
    		if ( pfc==null ) { pfc=new PrivateFontCollection(); }
    	}
    		
    	public static void AddMemoryFont(byte[] fontResource) {
    		IntPtr p;
    		uint c = 0;
    			
    		p=Marshal.AllocCoTaskMem( fontResource.Length );
    		Marshal.Copy( fontResource, 0, p, fontResource.Length );
    		AddFontMemResourceEx( p, (uint)fontResource.Length, IntPtr.Zero, ref c );
    		pfc.AddMemoryFont( p, fontResource.Length );
    		Marshal.FreeCoTaskMem( p );
    			
    		p = IntPtr.Zero;
    	}
    		
    	public static Font GetFont( int fontIndex, float fontSize = 20, FontStyle fontStyle = FontStyle.Regular ) {
    		return new Font(pfc.Families[fontIndex], fontSize, fontStyle);
    	}
    
    	// Useful method for passing a 4 digit hex string to return the unicode character
    	// Some fonts like FontAwesome require this conversion in order to access the characters
    	public static string UnicodeToChar( string hex ) {
    		int code=int.Parse( hex, System.Globalization.NumberStyles.HexNumber );
    		string unicodeString=char.ConvertFromUtf32( code );
    		return unicodeString;
    	}
    
    }
