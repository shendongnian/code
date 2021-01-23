    public static long GetListSize2(SPList list)
    {
        long byteSize = 0;
        long fileSize = 0;
        foreach (SPListItem item in list.Items)
        {
            if (item.ParentList.EnableVersioning == true && item.Versions.Count > 1)
            {
                for (int i = 0; i < item.Versions.Count; i++)
                {
                    if (long.TryParse(item.Versions[i]["File_x0020_Size"].ToString(), out fileSize) == false)
                        fileSize=0;
                    byteSize += fileSize;
                }
            }
            else
            {
                if (long.TryParse(item["File_x0020_Size"].ToString(), out fileSize) == false)
                        fileSize=0;
                long.TryParse(item["File_x0020_Size"].ToString(), out fileSize);
                byteSize += fileSize;
            }
        }
        return byteSize;
    }
