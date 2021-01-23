        public void insertListMember(int outerShpID, int innerShpID, int position)
        {
            acWindow.DeselectAll();
            Visio.Page page = acWindow.Page;
            acWindow.Select(page.Shapes.get_ItemFromID(innerShpID), (short)Microsoft.Office.Interop.Visio.VisSelectArgs.visSelect);
            Debug.WriteLine("Application.ActivePage.Shapes.ItemFromID(" + outerShpID + ").ContainerProperties.InsertListMember ActiveWindow.Selection," + position);
            ActiveDoc.ExecuteLine("Application.ActivePage.Shapes.ItemFromID(" + outerShpID + ").ContainerProperties.InsertListMember ActiveWindow.Selection," + position);
        }
