    List<PlantViewModel> plantsToRemove = new List<PlantViewModel>();
    foreach (PlantViewModel plant in Plants)
            {
                if (plant.Living == "No") 
                {
                plantsToRemove.Add(plant);  
                }
            }
             foreach(var plant in plantsToRemove)
                 Plants.Remove(plant);
            PlantsViewSource.Source = Plants;
            PlantsGridView.SelectedItem = null;
