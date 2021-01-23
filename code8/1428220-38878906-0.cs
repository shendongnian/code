    foreach (var referralDiaryEvent in referralDiaryEvents)
    {
        // create a NEW instance for every event!
        var timelineDetailsViewModel = new TimelineDetailsViewModel();
        timelineDetailsViewModel.EventDate = referralDiaryEvent.App_DiaryEvent.EventDateTimeScheduled;
        timelineDetailsViewModel.EventType = referralDiaryEvent.App_DiaryEvent.Ref_EventType.Description;
        timelineDetailsViewModel.EventDescription = referralDiaryEvent.App_DiaryEvent.EventName;
        viewModel.TimeLineList.Add(timelineDetailsViewModel);
    }
