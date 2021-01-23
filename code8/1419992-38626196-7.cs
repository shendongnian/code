            StatusList statusList = new StatusList();
            statusList.Add(new StatusSql());
            statusList.Add(new StatusInfo());
            var status = statusList.GetFirstFoundStatus(test);
            return status != null ? status.Color : Color.White;
