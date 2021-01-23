    private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
               try(){
             var rec = new SpeechRecognizer(new Windows.Globalization.Language("pt-BR"));
            await rec.CompileConstraintsAsync();
            rec.UIOptions.AudiblePrompt = "Aguardando o comando";
            var stream = await rec.RecognizeWithUIAsync();
                }
             catch(Exception e)
               {
                 Debug.WriteLine(e);
                }
 
        }
