        protected void CheckGoodRequest(Guid id)
        {
            if (id == null)
            {
                throw new HttpException(400, "There was something wrong with your request. Please try again.");
            }
        }
