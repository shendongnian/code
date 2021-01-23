    <Button>
      <Image Source="something.png">
        <Image.Style>
          <Style TargetType="Image">
            <Style.Triggers>
              <Trigger Property="IsEnabled" Value="False">
                <Setter Property="Opacity" Value="0.5" />
              </Trigger>
            </Style.Triggers>
          </Style>
        </Image.Style>
      </Image>
    </Button>
