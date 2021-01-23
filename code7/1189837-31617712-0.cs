            Cube cube = database.Cubes.FindByName(cubeName);
            MeasureGroup sampleMeasureGroup = cube.MeasureGroups[0];
            DataItem di = sampleMeasureGroup.Measures[0].Source;
            if (di == null) return null;
            ColumnBinding cb = di.Source as ColumnBinding;
            RowBinding rb = di.Source as RowBinding;
            string sTableID = (cb != null ? cb.TableID : (rb != null ? rb.TableID : null));
            if (sTableID == null) return null;
            if (cube.DataSourceView.Schema.Tables[sTableID] != null)
            {
                if (cube.DataSourceView.Schema.Tables[sTableID].ExtendedProperties.ContainsKey("FriendlyName"))
                {
                    return cube.DataSourceView.Schema.Tables[sTableID].ExtendedProperties["FriendlyName"].ToString();
                }
                else
                {
                    return cube.DataSourceView.Schema.Tables[sTableID].TableName;
                }
            }
            else
            {
                return sTableID;
            }
