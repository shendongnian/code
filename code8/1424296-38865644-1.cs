    IQueryable<ShowMedicineViewModel> query;
    List<ShowMedicineViewModel> medic = new List<ShowMedicineViewModel>();
    var medicineInfo = _dbContext.medicine_details.Where(m => (m.Medicine_name.StartsWith(medicinename)) && (m.Medicine_type == medicinetype)).ToList();   
    
    List<string> TotalMedicine = new List<string>();
  
    var results = (medicineInfo.OrderBy(x => x.id)
                  .Skip((pages - 1) * 2)
                  .Take(2));
    
    
    Parallel.ForEach(results, item =>
    {
        var temp = Mapper.DynamicMap<medicine_details, ShowMedicineViewModel>(item);
    
        medic.Add(temp);
    });
                   
    Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
    dictionary2.Add("CurrentPage", pages);
    dictionary2.Add("TotalPages", medicineInfo.Count() / 2 < 1 ? 1 : medicineInfo.Count());
           
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    dictionary.Add("Data", medic);
    dictionary.Add("Page", dictionary2);
    
    return dictionary;
