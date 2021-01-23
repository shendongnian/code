    [Route("api/day/weekday/{q_day}")]
    public IHttpActionResult GetDayWeek(string q_day) {
        var day = controller.GetDay(q_day);
        if (day == null) {
            return NotFound();
        }
        return Ok(day);
    }
