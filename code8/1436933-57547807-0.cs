        [HttpGet, Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetailsResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetailsResponse))]
        public async Task<IEnumerable<TResponse>> GetAll(int imoNo)
        {
            var parameters = await _parameterService.GetAllAsync(imoNo);
            return parameters.Select(x => MapToResponse(x));
        }
