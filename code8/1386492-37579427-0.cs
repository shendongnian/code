    protected CreatedNegotiatedContentResult<T> Created<T>(T content)
            {
                var props =typeof(T).GetProperties().Where(
                    prop => Attribute.IsDefined(prop, typeof(UniqueIdAttribute)));
                var id = props.FirstOrDefault().GetValue(content).ToString();
                return base.Created(new Uri(Request.RequestUri + id), content);
            }
