            //At the start
            var meteringPoints = MeteringPointsDataTable.AsEnumerable().ToDictionary(r => r.Field<string>("MeteringPointId").ToString());
            //For each row of the text file:
            DataRow row;
            if (!meteringPoints.TryGetValue(MeteringPointId, out row))
            {
                row = MeteringPointsDataTable.NewRow();
                meteringPoints[MeteringPointId] = row;
            }
