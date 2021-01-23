            var allRegistrations = await _hub.GetAllRegistrationsAsync(0);
            var continuationToken = allRegistrations.ContinuationToken;
            var registrationDescriptionsList = new List<RegistrationDescription>(allRegistrations);
            while (!string.IsNullOrWhiteSpace(continuationToken))
            {
                var otherRegistrations = await _hub.GetAllRegistrationsAsync(continuationToken, 0);
                registrationDescriptionsList.AddRange(otherRegistrations);
                continuationToken = otherRegistrations.ContinuationToken;
            }
            // Put into DeviceInstallation object
            var deviceInstallationList = new List<DeviceInstallation>();
            foreach (var registration in registrationDescriptionsList)
            {
                var deviceInstallation = new DeviceInstallation();
                var tags = registration.Tags;
                foreach(var tag in tags)
                {
                    if (tag.Contains("InstallationId:"))
                    {
                        deviceInstallation.InstallationId = new Guid(tag.Substring(tag.IndexOf(":")+1));
                    }
                }
                deviceInstallation.PushHandle = registration.PnsHandle;
                deviceInstallation.Tags = new List<string>(registration.Tags);
                deviceInstallationList.Add(deviceInstallation);
            }
