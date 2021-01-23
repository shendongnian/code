        void GridView_ClearColumnGroups(ASPxGridView theGridView)
        {
            foreach (GridViewDataColumn gvdc in theGridView.Columns)
            {
                if (gvdc != null && gvdc.GroupIndex >= 0)
                {
                    gvdc.GroupIndex = -1;
                    gvdc.UnGroup();
                }
            }
        }
            
