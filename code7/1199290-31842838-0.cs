      string file = @"pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Subfolder/TextFile.txt";
          using (StreamReader sr = new StreamReader(System.Windows.Application.GetResourceStream(new Uri(file)).Stream))
          {
              string TextFileData= sr.ReadToEnd();
          }
