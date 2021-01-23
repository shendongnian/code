        private void AddData(PriceVarianceData _pvd)
        {
            // Note changed column index (from 0 to 1)
            var UnitCell = (Excel.Range)_xlSheet.Cells[_currentTopRow, 1];
            UnitCell.Value2 = _pvd.Unit;
        
            // Note changed column index (from 1 to 2)
            var ShortNameCell = (Excel.Range)_xlSheet.Cells[_currentTopRow, 2];
            
            ShortNameCell.Value2 = _pvd.ShortName;
            . . .
        }
