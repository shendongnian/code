            var patients = patientEffort.GroupBy(x => x.Value.FirstName);   // group patients by name
            foreach (var patient in patients)
            {
                var res = new List<int>();
                foreach (var note in patient)  // collect all meal types of current patient
                    res.Add(note.Value.MealType);
                if (_listMealType.Intersect(res).Count() == _listMealType.Count)  // if intersection count equal to source meal list - it's our patient.
                    result.Add(patient.First());  // add information about patient. because we need only name - we can use first record in list.
            }
