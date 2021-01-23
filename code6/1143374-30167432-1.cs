       public partial class MainWindow : Window
       {
          private BackgroundWorker bw = new BackgroundWorker();
    
          public MainWindow()
          {
             InitializeComponent();
    
             CboDivisions.DataContext = new List<string>() { "red", "blue", "green" };
             CboDivisions.SelectionChanged += CboDivisions_SelectionChanged;
    
             bw.DoWork += bw_DoWork;
             bw.RunWorkerCompleted += bw_RunWorkerCompleted;
          }
    
          void CboDivisions_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
             var division = CboDivisions.SelectedValue as string;
             bw.RunWorkerAsync(division);
          }
    
          void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
          {
             CboList.DataContext = e.Result as List<string>;
          }
    
          void bw_DoWork(object sender, DoWorkEventArgs e)
          {
             var division = e.Argument as string;
    
             var r = new Random();
             var result = new List<string>();
    
             for(int i = 0; i < r.Next(0, 10); ++i)
             {
                result.Add(string.Format("{0} #{1}", division, i+1));
             }
    
             e.Result = result;
          }
       }
