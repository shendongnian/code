    public class Form1 : Form {
        Dictionary<int, CancellationTokenSource> cts = new Dictionary<int, CancellationTokenSource>();
        int tabID = 0;
    
        private async void searchButton_Click(object sender, EventArgs e){
    
            CancellationTokenSource temp = new CancellationTokenSource();
            tabID++;    
            TabPage tp = new TabPage(); 
            tp.Tag = tabID;
            tabControl1.TabPages.Add(tp);
            var resultData = await Task.Run(() => SlowMethod());
            if (!temp.Token.IsCancellationRequested) { /* add resultData to tabPage */ }
           cts.Add(tabID, temp);  
        }
    
        private void tabControl_MouseDown(object sender, MouseEventArgs e){
            // - I select the tab being hovered with mouse 
            // - I remove the tab from tabControl
            TabPage tp = .... select the tabpage from the mouse position
            CancellationTokenSource temp = cts[Convert.ToInt32(tp.Tag)]
            temp.Cancel();
        }
    }
