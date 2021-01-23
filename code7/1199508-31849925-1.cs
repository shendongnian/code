    public class Foo : ICloneable
    {
        //some fields....
        public object Clone()
        {
            return new Foo()
            {
                Zipcode = Zipcode,
                StateCode = StateCode,
                SalesData = SalesData== null ? null : SalesData.Copy(),
                OtherDataTable = OtherDataTable == null ? null : OtherDataTable.Copy(),
                VehicleDetails = VehicleDetails.Clone() as VehicleDetails,
                VehicleCondition = VehicleCondition.Clone() as VehicleCondition,
            };
        }
    }
