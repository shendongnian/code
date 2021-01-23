    public class Form1 : Form {
        private async void searchButton_Click(object sender, EventArgs e){
            CancellationTokenSource cts = new CancellationTokenSource();
            TabPage myNewTab = new TabPage(); 
            myNewTab.Tag = cts;
            tabControl1.TabPages.Add(myNewTab);
            var resultData = await Task.Run(() => SlowMethod());
            if (!cts.Token.IsCancellationRequested) { /* add resultData to tabPage */ }
        }
        private void tabControl_MouseDown(object sender, MouseEventArgs e){
            // - I select the tab being hovered with mouse 
            // - I remove the tab from tabControl
            CancellationTokenSource cts = (CancellationTokenSource)tabControl1.SelectedTab.Tag;
            cts.Cancel();
        }
    }
