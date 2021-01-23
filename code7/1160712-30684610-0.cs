    string _TextBoxData = "No data";
    bool _ChkBox1Data = false;
    ...
    try{
      System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
      _TextBoxData = file.ReadLine();
      _ChkBox1Data = Conver.ToBoolean(file.ReadLine());
    }catch(Exception e){
      MessageBox.Show(ex.ToString());
    }
    ...
    private void Form1_Load(){
      
      TextBox1.Text = TextBoxData;
      CheckBox1.Checked = ChkBox1Data;
    
    }
