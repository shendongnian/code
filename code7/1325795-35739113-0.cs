	public SampleDTO SampleServiceMethod(InputModel input)
    {
        var model = _sampleRepository.FindBy(input.Id);
        var dto = SampleMapper.ToSampleDto(model);
        // do something and return the dto
        dto.Test = 1;
        return dto;
    }
