    // First we collect the relevant games.
    var games =
        db
            .Games
            .Where(game => game.UserId == userId);
    // Then we collect the events of the collected games that have the specified event type.
    var events = 
        db
            .Events
            .Join(
                games,
                gameEvent => gameEvent.GameId,
                game => game.GameId,
                (gameEvent, game) => gameEvent
            )
            .Where(gameEvent => gameEvent.EventType == 35);
    // Then we collect the target objects based on the collected events.
    var targetObjects =
        db
            .TargetObjects
            .Join(
                events,
                targetObject => targetObject.TargetObjectId,
                gameEvent => gameEvent.TargetObjectId,
                (targetObject, gameEvent) => targetObject
            );
    // Last we select the target name from the collected target objects.
    var records =
        targetObjects
            .Select(targetObject => targetObject.TargetName)
            .ToList(); // The query will be executed at this point.
