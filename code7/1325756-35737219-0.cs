                List<MovementObject> movements = new List<MovementObject>()
                {
                    new MovementObject() { MovementId = 1, MovedFrom = "Sydney", MovedTo = "Melbourne"},
                    new MovementObject() { MovementId = 2, MovedFrom = "Dallas", MovedTo = "Boston"},
                    new MovementObject() { MovementId = 3, MovedFrom = "Boston", MovedTo = "Dallas"},
                    new MovementObject() { MovementId = 4, MovedFrom = "Boston", MovedTo = "Dallas"},
                    new MovementObject() { MovementId = 5, MovedFrom = "Sydney", MovedTo = "Brisbane"},
                };
    
                var categories = movements
                .Select(m => new[] { m.MovedFrom, m.MovedTo })
                .SelectMany(i => i)
                .Distinct()
                .ToList();
    
                MovementChartViewModel viewModel = new MovementChartViewModel();
    
                foreach(var category in categories.OrderBy(category => category)) //For alphabetical order
                {
                    viewModel.Categories.Add(category);
                    viewModel.Leaving.Add(movements.Where(move => move.MovedFrom == category).Count());
                    viewModel.Arriving.Add(movements.Where(move => move.MovedTo == category).Count());
                }
                return Json(new { viewModel });
    
