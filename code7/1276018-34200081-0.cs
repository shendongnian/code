           if (!string.IsNullOrEmpty(request.Form.Get("isNew")))
            {
                vehicle.IsNew = true;
            }
            else
            {
                vehicle.IsNew = false;
            }
