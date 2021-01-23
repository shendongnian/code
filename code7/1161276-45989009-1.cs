    [HttpPut]
    public IHttpActionResult Put(int id, Product product)
    {
        IHttpActionResult ret;
        try
        {
            // remove pre-check because it locks the record
            // var e = unitOfWork.ProductRepository.GetByID(id);
            //  if (e != null) {
            var toSave = _mapper.Map<ProductEntity>(product);
            unitOfWork.ProductRepository.Update(toSave);
            unitOfWork.Save();
            var p = _mapper.Map<Product>(toSave);
            ret = Ok(p);
            // }
            // else
            //    ret = NotFound();
        }
        catch (DbEntityValidationException ex)
        {
            ret = BadRequest(ValidationErrorsToMessages(ex));
        }
        catch (Exception ex)
        {
            ret = InternalServerError(ex);
        }
        return ret;
    }
