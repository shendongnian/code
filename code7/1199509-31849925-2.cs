    public class Foo : ICloneable
    {
        //some fields....
        private int _Bar; //private field
        public void SetBar(int value) { _Bar = value; } //Field setter        
        public object Clone()
        {
            var result = new Foo()
            {
                _Bar = _Bar, // private members are accessible from their scope, even when object is different
                Zipcode = Zipcode,
                StateCode = StateCode,
                SalesData = SalesData== null ? null : SalesData.Copy(),
                OtherDataTable = OtherDataTable == null ? null : OtherDataTable.Copy(),
                VehicleDetails = VehicleDetails.Clone() as VehicleDetails,
                VehicleCondition = VehicleCondition.Clone() as VehicleCondition,
            };
            // alternatively you can call setter methods
            result.SetBar(_Bar);
            return result;
        }
    }
