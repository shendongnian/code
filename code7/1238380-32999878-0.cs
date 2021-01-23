    public static void foo(String path) {
                try {
                    DirectoryInfo DirInfo = new DirectoryInfo(path);
                    foreach (FileInfo fi in DirInfo.GetFiles("*.*", SearchOption.AllDirectories)){
                        XmlSerializer serializer = new XmlSerializer(typeof(Response));
                        Response i;
                        FileStream fs = null;
                        fs = new FileStream(fi.FullName, FileMode.Open);
                    }
                } catch (Exception ex) {
                    Log.Error(ex);
                }
            }
