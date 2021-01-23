            foreach (KeyValuePair<Type, Type> item in AllModelTypes)
            {
                Type modelType = item.Key;
                Type linqType = item.Value;
                List<ModelBase> modelList = GetModelList<ModelBase>(modelType);
                // !!!! ^^^^^^ error that it can't implicitly convert
                //             List<modelType> to List<Modelbase>
                modelList.Clear();
                var ModelFactoryFromLinq = modelType.GetMethod("ModelFactoryFromLinq");
                modelList.AddRange(LoadListOfModels(filter, modelFactoryFromLinq));
                // !!!! ^^^^^^ error that "linqType"/"modelType" are variables,
                //             but get used like types; and that
                //             Type has no definition for "ModelFactoryFromLinq
            }
