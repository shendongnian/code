	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Input;
	namespace <YOUR_NAMESPACE>
	{
		sealed class SecondaryIconButton : AppBarToggleButton
		{
			public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
				"Glyph", typeof( string ), typeof( SecondaryIconButton )
				, new PropertyMetadata( SegoeMDL2.Accept, OnGlyphChanged ) );
			public string Glyph
			{
				get { return ( string ) GetValue( GlyphProperty ); }
				set { SetValue( GlyphProperty, value ); }
			}
			private TextBlock GlyphText;
			public SecondaryIconButton( string Glyph )
				:base()
			{
				IsChecked = true;
				this.Glyph = Glyph;
			}
			protected override void OnApplyTemplate()
			{
				base.OnApplyTemplate();
				GlyphText = ( TextBlock ) GetTemplateChild( "OverflowCheckGlyph" );
				GlyphText.Width = GlyphText.Height = 16;
				UpdateGlyph();
			}
			// Force the button to always be checked
			protected override void OnPointerReleased( PointerRoutedEventArgs e )
			{
				base.OnPointerReleased( e );
				IsChecked = true;
			}
			private void UpdateGlyph()
			{
				if ( GlyphText == null ) return;
				GlyphText.Text = Glyph;
			}
			private static void OnGlyphChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
			{
				( ( SecondaryIconButton ) d ).UpdateGlyph();
			}
		}
	}
