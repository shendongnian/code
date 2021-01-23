    public class Car
    {
        .....
        public override string ToString()
        {
            return string.Format("{{ Id = {0}, Company = {1}, Model = {2}, PlateNumber ={3} }}", this.Id, this.Company,
                this.Model, this.PlateNumber);
        }
    }
