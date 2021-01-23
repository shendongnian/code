    namespace nmsD
    {
    	public interface IdBase
    	{
    		string s_dBase { get; set; }
    		void methodX( );
    		void Dq1( );
    	}
    
    }
    
    namespace nmsB
    {
    	using nmsD;
    
    	public class bRegular01 : IdBase
    	{
    		public bRegular01( )
    		{
    			Console.WriteLine( "Construc_bRegular01" );
    			s_dBase = "Prop.bRegular01.01";
    		}
    
    		public string s_dBase { get; set; }
    
    		public void methodX( )
    		{
    			Console.WriteLine( "--->bRegular01_methodX (OK)" );
    		}
    
    		public void Dq1( )
    		{
    			Console.WriteLine( "Dq1: {0}", s_dBase );
    			methodX( );
    		}
    	}
    
    	public class bRegular02 : IdBase
    	{
    		public bRegular02( )
    		{
    			Console.WriteLine( "Construc_bRegular02" );
    			s_dBase = "Prop.bRegular02.02";
    		}
    
    		public string s_dBase { get; set; }
    
    		public void methodX( )
    		{
    			Console.WriteLine( "--->bRegular02_methodX (OK)" );
    		}
    
    		public void Dq1( )
    		{
    			Console.WriteLine( "Dq1: {0}", s_dBase );
    			methodX( );
    		}
    	}
    }
    
    
    namespace nmsApp
    {
    	internal class Program
    	{
    		private static void Main( string[ ] args )
    		{
    			nmsB.bRegular01 br01 = new nmsB.bRegular01( );
    			br01.Dq1( );
    
    			nmsB.bRegular02 br02 = new nmsB.bRegular02( );
    			br02.Dq1( );
    
    			Console.ReadKey( );
    		}
    	}
    }
