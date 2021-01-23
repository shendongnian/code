    public class MyClassUnderTest {
        public DataTable ConvertCellSetToDataTable(ICellSetWrapper cellSet) {
            if (cellSet == null) {
                return null;
            }
            var dataTable = new DataTable();
            SetColumns(cellSet, dataTable);
            WriteValues(cellSet, dataTable);
            return dataTable;
        }
        private void WriteValues(ICellSetWrapper cellSet, DataTable dataTable) {
            //...assign value to datarows
        }
        private void SetColumns(ICellSetWrapper cellSet, DataTable dataTable) {
            //...read data from this CellSet and build data columns
        }
    }
    public interface ICellSetWrapper {
        //...Methods and propeties exposing what you want to use
    }
    public class MyCellSetWrapper : ICellSetWrapper {
        CellSet cellSet;
        public MyCellSetWrapper(CellSet cellSet) {
            this.cellSet = cellSet;
        }
        //...Implemented methods/properties
    }
 
