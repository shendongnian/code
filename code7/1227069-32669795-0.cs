     private void version_check_Click(object sender, EventArgs e)
            {
               string version =   "F:\\first_folder\\Node3_V_1.3";
               var result = version.Substring(version.LastIndexOf('\\') + 1);
               string[] splitString = result.Split('_').ToArray();
               MessageBox.Show("upgrading "+ splitString[0] + " to version" + splitString[2]);
    
            }
