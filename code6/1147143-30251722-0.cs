    XMLTreeView.BeginUpdate();
    try
    {
        CreateTreeViewFromATXML(strSrcFileName);
    }
    catch (Exception e)
    {
        //Handle any error
    }
    finally
    {
        XMLTreeView.EndUpdate();
    }
