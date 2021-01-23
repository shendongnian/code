    CreateGeofence(new BasicGeoposition() { Longitude = double.Parse(VersionObject.store.lng), Latitude = double.Parse(VersionObject.store.lat) }, 200);
                                try
                                {
                                    var backgroundStatus = await BackgroundExecutionManager.RequestAccessAsync();
                                    var geofenceBuilder = new BackgroundTaskBuilder
                                    {
                                        Name = "Test Geofence",
                                        TaskEntryPoint = "GeofencingTask.BackgroundGeofencing"
                                    };
                                    var trigger = new LocationTrigger(LocationTriggerType.Geofence);
                                    geofenceBuilder.SetTrigger(trigger);
                                    var geofenceTask = geofenceBuilder.Register();
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.Message);
                                }
