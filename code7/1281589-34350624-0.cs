            Excel.Application app = new Excel.Application();
            //app.ActiveWindow.DisplayGridlines = false;//Error
            Excel.Workbooks workbooks = app.Workbooks;
            //app.ActiveWindow.DisplayGridlines = false;//Error
            workbooks.Open(filename);
            app.ActiveWindow.DisplayGridlines = false;//No Error
