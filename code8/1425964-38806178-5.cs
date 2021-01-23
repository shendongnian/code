    List<List<string>> items = new List<List<string>>();
    List<DateTime> firstColumnDates = new List<DateTime>(Enumerable.Range(1, 31).Select(x => new DateTime(2016, 8, x)));
    for (int j = 0; j < firstColumnDates.Count; j++) {
        items.Add(new List<string>());
    }
    List<FrigoriferoClass> rawSource = new List<FrigoriferoClass>();
    rawSource.Add(new FrigoriferoClass(1,"1",1,2));
    rawSource[0].controllo.Add(new ControlloClass(12, new DateTime(2016, 8, 6)));
    rawSource[0].controllo.Add(new ControlloClass(13, new DateTime(2016, 8, 8)));
    rawSource.Add(new FrigoriferoClass(2,"2",1,2));
    rawSource[1].controllo.Add(new ControlloClass(3, new DateTime(2016, 8, 2)));
    rawSource[1].controllo.Add(new ControlloClass(5, new DateTime(2016, 8, 7)));
    Dictionary<int, int> mapping = new Dictionary<int, int>();
    for (int j = 0; j < rawSource.Count; j++) {
        mapping[rawSource[j].codice] = j;
    }
    int i = 0;
    foreach (DateTime date in firstColumnDates) {
        for (int j = 0; j < rawSource.Count + 1; j++) {
            items[i].Add(string.Empty);
        }
        items[i][0] = date.ToShortDateString();
        foreach (var item in from x in rawSource
                             from y in x.controllo
                             where y.data == date
                             select new {col = x.codice, val = y.temp.ToString(CultureInfo.InvariantCulture)}) {
            items[i][mapping[item.col] + 1] = item.val;
        }
        i++;
    }
    var result = new ObservableCollection<object>();
    foreach (List<string> item in items) {
        //create the builder
        AssemblyName assembly = new AssemblyName("SOCodice");
        AppDomain appDomain = System.Threading.Thread.GetDomain();
        AssemblyBuilder assemblyBuilder = appDomain.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assembly.Name);
        //create the class
        TypeBuilder typeBuilder = moduleBuilder.DefineType("FrigoriferoClassColumn", TypeAttributes.Public | TypeAttributes.AutoClass | TypeAttributes.AnsiClass |
                                                            TypeAttributes.BeforeFieldInit, typeof(object));
        //create the FirstName property
        PropertyBuilder daysProperty = typeBuilder.DefineProperty("Days", System.Reflection.PropertyAttributes.HasDefault, typeof(string), null);
        //create the FirstName Getter
        MethodBuilder daysPropertyGetter = typeBuilder.DefineMethod("get_Days", MethodAttributes.Public | MethodAttributes.SpecialName |
                                                                          MethodAttributes.HideBySig, typeof(string), Type.EmptyTypes);
        ILGenerator daysPropertyGetterIL = daysPropertyGetter.GetILGenerator();
        daysPropertyGetterIL.Emit(OpCodes.Ldstr, item[0]);
        daysPropertyGetterIL.Emit(OpCodes.Ret);
        daysProperty.SetGetMethod(daysPropertyGetter);
        int k = 0;
        foreach (int column in mapping.Keys) {
            //create the FirstName property
            PropertyBuilder codiceProperty = typeBuilder.DefineProperty(column.ToString(CultureInfo.InvariantCulture), System.Reflection.PropertyAttributes.HasDefault, typeof(string), null);
            //create the FirstName Getter
            MethodBuilder codicePropertyGetter = typeBuilder.DefineMethod("get_" + column, MethodAttributes.Public | MethodAttributes.SpecialName |
                                                                              MethodAttributes.HideBySig, typeof(string), Type.EmptyTypes);
            ILGenerator codicePropertyGetterIL = codicePropertyGetter.GetILGenerator();
            codicePropertyGetterIL.Emit(OpCodes.Ldstr, item[mapping[column] + 1]);
            codicePropertyGetterIL.Emit(OpCodes.Ret);
            codiceProperty.SetGetMethod(codicePropertyGetter);
            k++;
        }
        result.Add(Activator.CreateInstance(typeBuilder.CreateType()));
    }
    MyDataGrid.ItemsSource = result;
