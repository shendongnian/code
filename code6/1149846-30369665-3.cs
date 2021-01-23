    private void Excel_Drop(object dropObj, Range target)
        {
            String dragData = Convert.ToString(target.Value2);
            if (dragData.Equals("Action1"))
            {
                Application.SheetChange -= Excel_Drop;
                DoAction1();
                Application.SheetChange += Excel_Drop;
                return;
            }
            if (dragData.Equals("Action2"))
            {
                Application.SheetChange -= Excel_Drop;
                DoAction2();
                Application.SheetChange += Excel_Drop;
                return;
            }
        }
