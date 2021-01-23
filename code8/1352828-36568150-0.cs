    [RoutePrefix("api")]
        public class IngredientAdminController : ApiController
            {
                private RecipeManager.DTO.IngredientAdminDTO dto = new IngredientAdminDTO();
            [Route("PostIngredient")]
            [HttpPost]
            public HttpResponseMessage PostIngredient(Ingredient ingredient)
            {
                try
                {
                    CommandResult<Ingredient> result = dto.CreateIngredient(ingredient);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
    
                }
                catch (RecipeManagerException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
