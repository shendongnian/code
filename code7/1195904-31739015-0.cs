      public static bool CheckBoxListPopulate(CheckBoxList CbList, IList<T> liSource, string TextFiled, string ValueField)
        {
            try
            {
    
                CbList.Items.Clear();
                if (liSource.Count > 0)
                {
                    CbList.DataSource = liSource;
                    CbList.DataTextField = TextFiled;
                    CbList.DataValueField = ValueField;
                    CbList.DataBind();
                    return true;
                }
                else { return false; }
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
    
            }
        }
