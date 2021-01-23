     MWPivot.Items.Clear();
            MCSProgressIndicator.ActivateProgressIndicator(MCSManager.Instance.currentTextParams.COMMON_PLEASE_WAIT);
            if (MCSManager.Instance.MWMenuItemsList.MW_HEADER_LIST !=null)
            {
                mw_header_list = new List<SUBPARAM>();
                mw_header_list = MCSManager.Instance.MWMenuItemsList.MW_HEADER_LIST.SUB_PARAMS;
                foreach(var header in mw_header_list)
                {
                    PivotItem mwPivotItem = new PivotItem()
                    {
                        Name=header.SP_CODE,
                        Header=header.SP_TITLE
                    };
                    createViewForPivotItem(mwPivotItem, header.SP_CODE);
                    MWPivot.Items.Add(mwPivotItem);
                    //MWPivot.SelectionChanged += MWPivot_SelectionChanged;
                }
                if (userSettings.Contains("SelectedIndex"))
                    MWPivot.SelectedIndex = Int32.Parse(userSettings["SelectedIndex"].ToString());
                MCSProgressIndicator.deactivateProgressIndicator();
            }
