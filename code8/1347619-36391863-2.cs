    for (int i = 0; i < ObjectList.Count; i++)
    {
        try
        {
            Image img = //Get your image;
            Byte[] result = (Byte[])new ImageConverter().ConvertTo(img, typeof(Byte[]));
            Object.Image = result;
        }
        catch
        { }
    }
        
    bindingSource1.DataSource = objectList;
    dataGridView1.DataSource = bindingSource1;
