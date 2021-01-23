    return new HttpResponseMessage()
                {
                    Content = new ObjectContent<IList<PersonModel>>(
                        personModelList, // What we are serializing 
                        result.Formatter, // The media formatter
                        result.MediaType.MediaType // The MIME type
                        ),
                    StatusCode = HttpStatusCode.OK
                };
