                                 select new RoomViewModel
                                 {
                                     ID = r.ID,
                                     Nr = r.Nr,
                                     rType = t.Name,
                                     ImageBytes = r.Image as Byte[],
                                     ImageType = "image/jpg", // for example
                                     Description = r.Description,
                                     rFloor = f.Floor1
                                 }).ToList();
