        get
        {
            switch (index)
            {
                case 0:
                    return (int)List[index];
                case 1:
                case 2:
                    return (string)List[index];
                case 3:
                    return JsonConvert.DeserializeObject<ReportGrouping>(List[index].ToString());
                default:
                    throw new System.ArgumentOutOfRangeException("Class ReportTemplateField only contains 4 items");
            }
        }
