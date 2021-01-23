    public async Task<ServiceAvailabilityDTO> ServiceAvailabilityStatus()
    {
        return new ServiceAvailabilityDTO
        {
            IsDb1Online = await IsDb1Available(),
            IsDb2Online = IsDb2Available(),
            IsDb3Online = await IsDb3Available(this) // here 'this' does NOT ref to ServiceAvailabilityDTO
        };
    }
