    [HttpPatch("{id}", Name = nameof(PatchDepartment))]
    [HttpCacheFactory(0, ViewModelType = typeof(Department))]
    public async Task<IActionResult> PatchDepartment(int id, [FromBody] JsonPatchDocument<DepartmentForUpdateDto> patch) // The patch operation is on the dto and not directly the entity to avoid exposing entity implementation details.
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var dto = new DepartmentForUpdateDto();
        patch.ApplyTo(dto, ModelState);                                                       // Patch a temporal DepartmentForUpdateDto dto "contract", passing a model state to catch errors like trying to update properties that doesn't exist.
        if (!ModelState.IsValid) return BadRequest(ModelState);
        TryValidateModel(dto);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _mediator.Send(new EditDepartmentCommand(id, patch.Operations.Where(o => o.OperationType == OperationType.Replace).ToDictionary(r => r.path, r => r.value))).ConfigureAwait(false);
        if (result.IsFailure && result.Value == StatusCodes.Status400BadRequest) return StatusCode(StatusCodes.Status404NotFound, result.Error);
        if (result.IsFailure && result.Value == StatusCodes.Status404NotFound) return StatusCode(StatusCodes.Status404NotFound, result.Error);
        if (result.IsFailure) return StatusCode(StatusCodes.Status500InternalServerError, result.Error);             // StatusCodes.Status500InternalServerError will be triggered by DbUpdateConcurrencyException.
        return NoContent();
    }
