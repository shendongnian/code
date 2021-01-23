    var newTests = source.TransformationTests.Select(
        c => new TransformationTest
            {
                // replicating other properties
                MediaFileMetaDatas = c.MediaFileMetaDatas.Select(m => new MediaFileMetaData {
                	Data = m.Data,
                	MediaFileDescriptor = new MediaFileDescriptor {
                		// copy data from existing descriptor
                	}
                }).ToList()
            });
