    public class EntityControllerConversion : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            ActionModel action = ... // finds the controller action 
            SetResponseUsingHack(action);
        }
        
        private void SetResponseUsingHack(ActionModel actionModel, Type responseType, HttpStatusCode statusCode)
        {
            if (actionModel == null) throw new ArgumentNullException(nameof(actionModel));
            if (responseType == null) throw new ArgumentNullException(nameof(responseType));
            var writable = (IList<object>)(actionModel.Attributes);
            var attribute = FindResponseAttributeUsingHack(writable, statusCode);
            if (attribute != null)
            {
                attribute.Type = responseType;
            }
        }
        private ProducesResponseTypeAttribute FindResponseAttributeUsingHack(IList<object> attributes, HttpStatusCode statusCode)
        {
            if (attributes == null) return null;
            var result = attributes.OfType<ProducesResponseTypeAttribute>()
                .Where(x => x.Type == typeof(ProducesResponseStub))
                .FirstOrDefault(x => x.StatusCode == (int) statusCode);
            return result;
        }
    }
    public abstract class EntityController<TEntity> 
    {
        [HttpGet]
        [ProducesResponseType(typeof(ProducesResponseStub), 200)]
        public IActionResult Get(string id)
        {
        }
    }
    public static class ProducesResponseStub
    {
    }
