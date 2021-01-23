     _repository.When(
        x => x.SaveStatistics(Arg.Any<Item>(), statistics)).Do(
            call =>
                {
                    itemUsed = call.Arg<Item>();
                    UpdateItem(itemUsed, statistics);
                });
