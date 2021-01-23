    private void Form1_Load(object sender, EventArgs e)
    {
       // Obtain a handle to the system image list.
       NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
       IntPtr hSysImgList = NativeMethods.SHGetFileInfo("",
                                                        0,
                                                        ref shfi,
                                                        (uint)Marshal.SizeOf(shfi),
                                                        NativeMethods.SHGFI_SYSICONINDEX
                                                         | NativeMethods.SHGFI_SMALLICON);
       Debug.Assert(hSysImgList != IntPtr.Zero);  // cross our fingers and hope to succeed!
    
       // Set the ListView control to use that image list.
       IntPtr hOldImgList = NativeMethods.SendMessage(listView1.Handle,
                                                      NativeMethods.LVM_SETIMAGELIST,
                                                      NativeMethods.LVSIL_SMALL,
                                                      hSysImgList);
    
       // If the ListView control already had an image list, delete the old one.
       if (hOldImgList != IntPtr.Zero)
       {
          NativeMethods.ImageList_Destroy(hOldImgList);
       }
    
       // Set up the ListView control's basic properties.
       // Put it in "Details" mode, create a column so that "Details" mode will work,
       // and set its theme so it will look like the one used by Explorer.
       listView1.View = View.Details;
       listView1.Columns.Add("Name", 500);
       NativeMethods.SetWindowTheme(listView1.Handle, "Explorer", null);
    
       // Get the items from the file system, and add each of them to the ListView,
       // complete with their corresponding name and icon indices.
       string[] s = Directory.GetFileSystemEntries(@"C:\...");
       foreach (string file in s)
       {
          IntPtr himl = NativeMethods.SHGetFileInfo(file,
                                                    0,
                                                    ref shfi,
                                                    (uint)Marshal.SizeOf(shfi),
                                                    NativeMethods.SHGFI_DISPLAYNAME
                                                      | NativeMethods.SHGFI_SYSICONINDEX
                                                      | NativeMethods.SHGFI_SMALLICON);
          Debug.Assert(himl == hSysImgList); // should be the same imagelist as the one we set
          listView1.Items.Add(shfi.szDisplayName, shfi.iIcon);
       }
    }
