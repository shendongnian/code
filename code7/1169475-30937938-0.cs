    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        int[] numbers = new int[5];
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;
        numbers[3] = 4;
        numbers[4] = 5;
        treeView1.Invoke((Action)delegate 
        {
           foreach (int element in numbers)
           {
               treeView1.Nodes.Add(element.ToString());
           }
       });
       button1.Invoke((Action) delegate { button1.Enabled = true; });
    }
