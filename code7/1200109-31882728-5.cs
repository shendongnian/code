           MapperActivations.AddInterfaceActivation<ICity, City>();
           Mapper.AddMap<Auto_From_Stored_Procedure, AutorDto>(src =>
                {
                    var res = new User();
                    res.InjectFrom<UnflatLoopCustomInjection>(src);
                    res.Posts = Mapper.Map<XElement, List<Posts>>(src.PostsXml , "PostDto"); //this is mapping using XmlSerializer, PostsXml is XElement.Parse(Posts) in Autor_From_Stored_Procedure.
                    return res;
                });
