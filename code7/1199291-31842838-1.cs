      string file = @"pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Subfolder/TextFile.txt";
          using (var sr = new StreamReader(System.Windows.Application.GetResourceStream(new Uri(file)).Stream))
          {
              var data= sr.ReadToEnd();
          }
