::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\\\?\usb#vid_04e8&pid_6860&ms_comp_mtp&samsung_android#6&fee689d&3&0000#{6ac27878-a6fa-4155-ba85-f98f491d4f33}\SID-{20002,SECZ9519043CHOHB01,63829639168}\{013C00D0-011B-0130-3A01-380113012901}
    public int Hwnd { get; private set; }
    private void button3_Click(object sender, EventArgs e)
    {
        Shell shell = new Shell();
        Folder folder = shell.BrowseForFolder((int)Hwnd, "Choose Folder", 0, 0);     
        if (folder == null)
        {
            // User cancelled
        }
        else
        {             
            FolderItem fi = (folder as Folder3).Self;
            //string path = fi.Path;
            UserFolderLocation = fi.Path;
        }
    }
