    namespace filereplacer
    {
       public partial class Form1 : Form
       {
          string sSelectedFile;
          string sSelectedFolder;
          public Form1()
          {
             InitializeComponent();
          }
          private void direc_Click(object sender, EventArgs e)
          {
             FolderBrowserDialog fbd = new FolderBrowserDialog();
             //fbd.Description = "Custom Description"; //not mandatory
             if (fbd.ShowDialog() == DialogResult.OK)      
                   sSelectedFolder = fbd.SelectedPath;
             else
                   sSelectedFolder = string.Empty;    
          }
          private void choof_Click(object sender, EventArgs e)
          {
             OpenFileDialog choofdlog = new OpenFileDialog();
             choofdlog.Filter = "All Files (*.*)|*.*";
             choofdlog.FilterIndex = 1;
             choofdlog.Multiselect = true;
    
             if (choofdlog.ShowDialog() == DialogResult.OK)                 
                 sSelectedFile = choofdlog.FileName;            
             else
                 sSelectedFile = string.Empty;       
          }
          private void replacebtn_Click(object sender, EventArgs e)
          {
              if(sSelectedFolder != string.Empty && sSelectedFile != string.Empty)
              {
                   //use selected folder path and file path
              }
          }
          ....
    }
