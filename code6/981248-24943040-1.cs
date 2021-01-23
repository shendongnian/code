    private void textBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
         if (textBlock.Opacity == 0.0)
         {
             FadeInTextBlock.Begin();
         }
         else
         {
             FadeOutTextBlock.Begin();
         }
    }
