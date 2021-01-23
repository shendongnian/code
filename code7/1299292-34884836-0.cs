    public class RetailCar
    {
      public string Name {get; set;}
      public string Type {get; set;}
    
      // rest propetties
    }
    DataGridViewRow rw = this.dataGridViewSimulatedTrainEditor.SelectedRows[0];
    RetailCar rc = new RetailCar
    {
      Name = rw.Cells["RetailCar Name"].Value.ToString();
      Type = rw.Cells["RetailCar Type"].Value.ToString();
    
      // fill rest properties
    };
