       public HttpResponseMessage Get(int id)
        {
            try
            {
                var person = _personRepository.GetById(id);
                var dto = Mapper.Map<PersonDto>(person);
                HttpResponseMessage response = Request.CreateResponse<PersonDto>(HttpStatusCode.OK, dto);
                return response;
            }
            catch (TextFileDataSourceException ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
            catch (DataResourceNotFoundException ex)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return response;
            }
            catch (FormatException ex)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
